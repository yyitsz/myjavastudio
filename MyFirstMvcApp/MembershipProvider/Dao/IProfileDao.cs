using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Dao;
using NHMembershipProvider.Entities;
using Framework.Attributes;
using Framework.Entity;
using NHibernate.Transform;

namespace NHMembershipProvider.Dao
{
    public interface IProfileDao : IBaseDao<Profile, int>
    {
        [Hql("from Profile p where p.UserId=:userId and p.IsAnonymous=:isAnonymous")] 
        Profile GetProfile(int userId, bool isAnonymous);

        [Hql( "from Profile p where p.UserId=:userId")] 
        Profile GetProfileByUserId(int userId);

        [Hql( "FROM Profile p WHERE p.ApplicationName=:appName AND p.IsAnonymous=:isAnonymous AND p.LastActivityDate <=:userInactiveSinceDate")] 
        IList<Profile> GetInactiveAndAnonymousProfile(string appName, DateTime userInactiveSinceDate, bool isAnonymous);

        [Hql("DELETE FROM Profile p WHERE p.ApplicationName=:appName AND p.IsAnonymous=:isAnonymous AND p.LastActivityDate <=:userInactiveSinceDate"
            ,IsQuery=false)]
        int DeleteInactiveAndAnonymousProfile(string appName, DateTime userInactiveSinceDate, bool isAnonymous);

        [Hql(
            @"SELECT u.Username, p.IsAnonymous, p.LastActivityDate, p.LastUpdatedDate, 0 
FROM Profile p LEFT JOIN User u ON p.UserId=u.id
WHERE @and{
    {p.ApplicationName=:appName},
    @if(userInactiveSinceDate){p.LastActivityDate <= :userInactiveSinceDate},
    @if(isAnaon){p.IsAnonymous = :isAnaon}
}", Count="p.id")]
          [PropertyTransformerAttribute]
        BaseSearchingResult<System.Web.Profile.ProfileInfo> SearchProfile(string appName, DateTime? userInactiveSinceDate, bool isAnaon);
    }
}
