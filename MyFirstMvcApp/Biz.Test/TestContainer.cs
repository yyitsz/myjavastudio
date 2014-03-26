using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfOrm;
using ConfOrm.NH;
using Biz.Model;
using NUnit.Framework;
using Biz.Extensions;
using NHibernate.Tool.hbm2ddl;
using Castle.DynamicProxy;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.MicroKernel.Registration;
using Framework.HbmMapper;
using Castle.Facilities.Logging;
using Castle.Facilities.AutoTx;
using Framework;
using Castle.Core;
using Framework.Dao;
using Framework.Executor;
using Framework.Interceptors;
using Framework.Transaction;
using Framework.Container;
using Common.Logging;
using Framework.Utils;
using Framework.Entity;
using Biz.Test.Services;
using Framework.NHibernateExt;
using Framework.Context;
using System.Threading;
using System.Threading.Tasks;

namespace Biz.Test
{
    [TestFixture]
    public class TestContainer
    {
        private ILog log = LogManager.GetLogger<TestContainer>();

        IMiniContainer miniContainer;
        IWindsorContainer container;

        TransactionTemplate txTemplate;
        IPersonDao dao;
        IPersonService personService;
        IContextProvider ctxProvider;

        [NUnit.Framework.TestFixtureSetUp]
        public void Begin()
        {
            log.Debug("Creating Container");

            container = new WindsorContainer();
            miniContainer = new WindsorContainerAdapter(container);
            container.Register(Component.For<IMiniContainer>().Instance(miniContainer));

            container.Register(Component.For<IHbmMapper>()
                .ImplementedBy<TestHbmMapper>()
                .LifeStyle.Transient);
            container.AddFacility<LoggingFacility>(f => f.LogUsing(LoggerImplementation.Log4net).WithAppConfig());
            container.AddFacility<TransactionManagerFacility>(
                tmf => tmf.Config()
                    .AddClass(typeof(PersonService))
                    .AddMethod("Update*", Castle.Services.Transaction.TransactionMode.Requires)
                    .AddMethod("Delete*", Castle.Services.Transaction.TransactionMode.Requires)
                    .AddMethod("Save*", Castle.Services.Transaction.TransactionMode.Requires)
                    .AddMethod("Create*", Castle.Services.Transaction.TransactionMode.Requires)
                    .AddMethod("Merge*", Castle.Services.Transaction.TransactionMode.Requires)
                    .AddMethod("Load*", Castle.Services.Transaction.TransactionMode.Supported)
                    .AddMethod("Find*", Castle.Services.Transaction.TransactionMode.Supported)
                    .AddMethod("Get*", Castle.Services.Transaction.TransactionMode.Supported)
                    .AddMethod("Search*", Castle.Services.Transaction.TransactionMode.Supported)
                    );

            container.Register(Component.For<IContextProvider>().ImplementedBy<CallDataContextProvider>());
            container.Register(Component.For<AuditEventListener>());


            container.Install(Configuration.FromXmlFile("context.xml"));
            container.Register(Component.For(typeof(IBaseDao<,>))
                .ImplementedBy(typeof(NHibernateBaseDao<,>)));

            container.Register(Component.For(typeof(TransactionTemplate))
                .ImplementedBy<TransactionTemplate>());

            container.Register(Component.For(typeof(IExecutor))
                .ImplementedBy<SqlExecutor>());
            container.Register(Component.For(typeof(IExecutor))
              .ImplementedBy<HqlExecutor>());
            container.Register(Component.For(typeof(IExecutor))
              .ImplementedBy<ImplementorExecutor>());

            container.Register(Component.For<DaoInterceptor>()
               .Parameters(Parameter.ForKey("sessionFactoryAlias").Eq("TestDb")));

            container.Register(Component.For(typeof(IPersonDao))
                .Interceptors(typeof(DaoInterceptor))
                );
            container.Register(Component.For(typeof(IAddressDao))
               .Interceptors(typeof(DaoInterceptor))
               );

            container.Register(Component.For(typeof(IPersonService))
                .ImplementedBy<PersonService>()
              );

            container.Register(Component.For<TestImplementor>().LifeStyle.Transient);

            log.Debug("Created Container");

            txTemplate = container.Resolve<TransactionTemplate>();
            dao = container.Resolve<IPersonDao>();

            personService = container.Resolve<IPersonService>();

            ctxProvider = container.Resolve<IContextProvider>();
        }

        [NUnit.Framework.SetUp]
        public void Setup()
        {
            UserContext ctx = new UserContext();
            ctx.UserId = "Jack";
            ctxProvider.SetContext(UserContext.USER_CONTEXT_KEY, ctx);

            int count = txTemplate.Execute(tx => dao.DeleteAll());
            Address a = new Address() { Street = "ShenNan", CivicNumber = 20000 };
            log.InfoFormat("Deleted {0} person records.", count);
            Person oldPerson = new Person() { Name = "Name1", Age = 30, Gender = Gender.Female, IsMarried = true, Address = a };
            dao.Create(oldPerson);
            oldPerson = new Person() { Name = "Name1", Age = 30, Gender = Gender.Female, IsMarried = false, Address = a };
            dao.Create(oldPerson);
            oldPerson = new Person() { Name = "Name2", Age = 40, Gender = Gender.Male, IsMarried = true, Address = a };
            dao.Create(oldPerson);
            oldPerson = new Person() { Name = "Name3", Age = 50, Gender = Gender.Female, IsMarried = false, Address = a };
            dao.Create(oldPerson);
            oldPerson = new Person() { Name = "Name4", Age = 60, Gender = Gender.Male, Address = a };
            dao.Create(oldPerson);
            oldPerson = new Person() { Name = "Name5", Age = 70, IsMarried = true };
            dao.Create(oldPerson);
        }

        [NUnit.Framework.TestFixtureTearDown]
        public void End()
        {
            miniContainer.Dispose();
            log.Debug("Disposed Container");
        }

        [NUnit.Framework.Test]
        [Ignore]
        public void TestUserContext()
        {

            Person p = new Person { Address = new Address { CivicNumber = 12323, Street = "abc" }, Name = "Jack_ADAFASDF", Gender = Gender.Male };
            // Person p2 = new Person { Address = new Address { CivicNumber = 12323, Street = "abc" }, Name = "Jack2", Gender = Gender.Male };
            txTemplate.Execute(tx =>
            {
                dao.SaveOrUpdate(p);
                // dao.SaveOrUpdate(p2);
            });

            Task task = Task.Factory.StartNew(() =>
                txTemplate.Execute(tx =>
                {
                    UserContext ctx = new UserContext();
                    ctx.UserId = "Jack2";
                    ctxProvider.SetContext(UserContext.USER_CONTEXT_KEY, ctx);
                    IList<Person> persons = dao.GetByName(p.Name);
                    Assert.Greater(persons.Count, 0);

                    persons[0].Gender = Gender.Female;
                }));

            task.Wait();
            txTemplate.Execute(tx =>
            {
                dao.Refresh(p);
                Assert.AreEqual("Jack2", p.UpdatedBy);
            });
        }

        [NUnit.Framework.Test]
         [Ignore]
        public void TestAuditable()
        {
            DateTime? oldTime = DateTime.Now;
            Person p = new Person { Address = new Address { CivicNumber = 12323, Street = "abc" }, Name = "Jack", Gender = Gender.Male };
            txTemplate.Execute(tx =>
            {
                dao.SaveOrUpdate(p);
            });
            oldTime = p.UpdatedAt;
            Thread.Sleep(100);
            txTemplate.Execute(tx =>
            {
                IList<Person> persons = dao.GetByName(p.Name);
                Assert.Greater(persons.Count, 0);

                persons[0].Gender = Gender.Female;
            });
            txTemplate.Execute(tx =>
          {
              dao.Refresh(p);
              Assert.Greater(p.UpdatedAt, oldTime);
          });
        }

        [NUnit.Framework.Test]
         [Ignore]
        public void TestSearchingWithCountingAndOrder()
        {
            var criteria = new SearchingPerson();
            criteria.OrderBy.Add(OrderBy.Create<PersonDto>(dto => dto.Name, Direction.DESC));
            BaseSearchingResult<PersonDto> persons = dao.SearchPersonDtoWithCountingAndOrder(criteria);

            Assert.AreEqual(6, persons.TotalRecords);
            Assert.IsNotNull(persons.Result);
            Assert.AreEqual(6, persons.Result.Count);
            Assert.AreEqual("Name5", persons.Result[0].Name);

        }

        [NUnit.Framework.Test]
       // [Ignore]
        public void TestConstructorTransformer()
        {
            var criteria = new SearchingPerson();

            criteria.Name = "Name4";

            IList<PersonDto> persons = dao.SearchPersonDto3(criteria);
            Assert.AreEqual(1, persons.Count);
            Assert.AreEqual("ShenNan", persons[0].Street);
        }

        [NUnit.Framework.Test]
         [Ignore]
        public void TestTransformer()
        {
            var criteria = new SearchingPerson();

            criteria.Name = "Name4";

            IList<PersonDto> persons = dao.SearchPersonDto2(criteria);
            Assert.AreEqual(1, persons.Count);
            Assert.AreEqual("ShenNan", persons[0].Street);
        }

        [NUnit.Framework.Test]
         [Ignore]
        public void TestTx()
        {
            txTemplate.Execute(tx =>
                {
                    personService.DeleteAll();
                    IList<Person> lists = personService.FindAllPersons();
                    Assert.AreEqual(0, lists.Count);

                });

        }

        [NUnit.Framework.Test]
        [Ignore]
        public void TestSearchingWithCounting()
        {
            var criteria = new SearchingPerson();

            BaseSearchingResult<PersonDto> persons = dao.SearchPersonDtoWithCounting(criteria);
            Assert.AreEqual(6, persons.TotalRecords);
            Assert.IsNotNull(persons.Result);
            Assert.AreEqual(6, persons.Result.Count);

        }

        [NUnit.Framework.Test]
        [Ignore]
        public void TestGenericType()
        {
            Type type = ReflectionHelper.GetGenericParameterTypeBaseOn(typeof(BaseSearchingResult<>), typeof(BaseSearchingResult<PersonDto>));
            Type type2 = ReflectionHelper.GetGenericParameterTypeBaseOn(typeof(BaseSearchingResult<>), typeof(PersonDtoSearchingResult));
            Type type3 = ReflectionHelper.GetGenericParameterTypeBaseOn(typeof(BaseSearchingResult<>), typeof(PersonDtoSearchingResult2));


            Type type4 = ReflectionHelper.GetGenericParameterTypeBaseOn(typeof(IList<>), typeof(IList<PersonDto>));
            Assert.AreEqual(type, type2);
            Assert.AreEqual(type, type3);
            Assert.AreEqual(type, type4);
            Assert.AreEqual(typeof(PersonDto), type);
        }

        [NUnit.Framework.Test]
        [Ignore]
        public void TestTransformer2()
        {
            var criteria = new SearchingPerson();

            criteria.Name = "Name4";

            IList<PersonDto> persons = dao.SearchPersonDto(criteria);
            Assert.AreEqual(1, persons.Count);
            Assert.AreEqual("ShenNan", persons[0].Street);
        }

        [NUnit.Framework.Test]
        [Ignore]
        public void TestUpdateDataInTx()
        {
            txTemplate.Execute(tx =>
                {
                    var criteria = new SearchingPerson();

                    criteria.Name = "Name5";

                    IList<Person> persons4 = dao.SearchPersons(criteria);
                    Assert.AreEqual(1, persons4.Count);
                    foreach (var p in persons4)
                    {
                        Console.WriteLine("Name: " + p.Name + ", Age: " + p.Age + ",Gender:" + p.Gender);
                    }
                    persons4[0].IsMarried = false;
                    persons4[0].Gender = Gender.Female;
                    persons4[0].Age = 20;
                });

            IList<Person> persons = dao.GetByName("Name5");
            Assert.AreEqual(1, persons.Count);
            Person person = persons[0];
            Assert.AreEqual(false, person.IsMarried);
            Assert.AreEqual(Gender.Female, person.Gender);
            Assert.AreEqual(20, person.Age);
        }

        [NUnit.Framework.Test]
        [Ignore]
        public void TestDynamicQuery2()
        {
            var criteria = new SearchingPerson();
            criteria.Gender = Gender.Female;
            criteria.IsMarried = true;

            IList<Person> persons4 = dao.SearchPersons(criteria);
            Assert.AreEqual(1, persons4.Count);
            foreach (var p in persons4)
            {
                Console.WriteLine("Name: " + p.Name + ", Age: " + p.Age + ",Gender:" + p.Gender);
            }
            IList<Person> persons5 = dao.SearchPersons(new SearchingPerson());
            Assert.AreEqual(6, persons5.Count);
        }

        [NUnit.Framework.Test]
        [Ignore]
        public void TestDynamicQuery()
        {
            IList<Person> persons4 = dao.SearchPersons(null, true);
            Assert.AreEqual(3, persons4.Count);
            foreach (var p in persons4)
            {
                Console.WriteLine("Name: " + p.Name + ", Age: " + p.Age);
            }
            IList<Person> persons5 = dao.SearchPersons(null, null);
            Assert.AreEqual(6, persons5.Count);
        }


        [NUnit.Framework.Test]
        [Ignore]
        public void TestTwoDao()
        {
            TransactionTemplate txTemplate = container.Resolve<TransactionTemplate>();
            IPersonDao dao = container.Resolve<IPersonDao>();
            IAddressDao addrDao = container.Resolve<IAddressDao>();

            Person oldPerson = new Person() { Name = "Miachel", Age = 30 };

            dao.Create(oldPerson);
            Assert.IsTrue(oldPerson.Id > 0);
            Person newPerson = dao.Load(oldPerson.Id);
            Assert.IsNotNull(newPerson);

            oldPerson = new Person() { Name = "ABCDED", Age = 30 };
            try
            {
                txTemplate.Execute<object>(tx =>
                    {
                        dao.Create(oldPerson);
                        addrDao.ThrowAnException(1, 2);
                        return null;
                    }
                 );
                Assert.Fail("Should catch exception.");
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            //Assert.IsTrue(oldPerson.Id == 0);
            IList<Person> persons = dao.GetByName(oldPerson.Name);


            Assert.IsTrue(persons.Count == 0);

        }
        [NUnit.Framework.Test]
        [Ignore]
        public void TestCreatUser()
        {
            TransactionTemplate txTemplate = container.Resolve<TransactionTemplate>();
            IPersonDao dao = container.Resolve<IPersonDao>();
            Person oldPerson = new Person() { Name = "Miachel", Age = 30 };

            txTemplate.Execute(tx => dao.Create(oldPerson));
            IList<Person> persons = txTemplate.Execute(tx => dao.FindAllPersons());

            foreach (var p in persons)
            {
                Console.WriteLine("Name: " + p.Name + ", Age: " + p.Age);
            }

            Console.WriteLine("Get Data as page.");
            IList<Person> persons2 = txTemplate.Execute(tx => dao.FindAllPersons(3, 2));

            foreach (var p in persons2)
            {
                Console.WriteLine("Name: " + p.Name + ", Age: " + p.Age);
            }

            Person newPerson = txTemplate.Execute(tx => dao.FindPerson(oldPerson.Id));

            Console.WriteLine("Name: " + newPerson.Name + ", Age: " + newPerson.Age);

            IList<Person> persons4 = txTemplate.Execute(tx => dao.FindPagninationPersons(3, 5));

            foreach (var p in persons4)
            {
                Console.WriteLine("Name: " + p.Name + ", Age: " + p.Age);
            }

            IList<Person> persons5 = txTemplate.Execute(tx => dao.FindPagninationPersons(2, 5));

            foreach (var p in persons5)
            {
                log.Info("Name: " + p.Name + ", Age: " + p.Age);
            }
        }

    }


}
