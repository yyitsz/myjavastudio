package org.yy.studyactiviti.config;

import java.beans.PropertyVetoException;

import javax.sql.DataSource;

import org.activiti.engine.HistoryService;
import org.activiti.engine.ManagementService;
import org.activiti.engine.ProcessEngine;
import org.activiti.engine.RepositoryService;
import org.activiti.engine.RuntimeService;
import org.activiti.engine.TaskService;
import org.activiti.spring.ProcessEngineFactoryBean;
import org.activiti.spring.SpringProcessEngineConfiguration;
import org.springframework.beans.factory.config.MethodInvokingFactoryBean;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.DependsOn;
import org.springframework.core.io.ClassPathResource;
import org.springframework.core.io.Resource;
import org.springframework.jdbc.datasource.DataSourceTransactionManager;
import org.springframework.jdbc.datasource.TransactionAwareDataSourceProxy;
import org.springframework.transaction.PlatformTransactionManager;

import com.mchange.v2.c3p0.ComboPooledDataSource;

@Configuration
public class AppContext {
	@Bean
	public DataSource dataSource() throws Throwable {

		TransactionAwareDataSourceProxy proxy = new TransactionAwareDataSourceProxy();
		proxy.setTargetDataSource(c3p0DataSource());

		return proxy;
	}

	@Bean(destroyMethod = "close")
	public DataSource c3p0DataSource() throws Throwable {
		ComboPooledDataSource cpds = new com.mchange.v2.c3p0.ComboPooledDataSource();
		cpds.setDriverClass("org.h2.Driver");
		cpds
				.setJdbcUrl("jdbc:h2:h2/activiti;DB_CLOSE_ON_EXIT=FALSE;TRACE_LEVEL_FILE=4");
		cpds.setUser("sa");
		cpds.setPassword("");

		return cpds;
	}

	@Bean
	public PlatformTransactionManager transactionManager() throws Throwable {
		DataSourceTransactionManager dt = new DataSourceTransactionManager();
		dt.setDataSource(dataSource());
		return dt;
	}

	@Bean
	public MethodInvokingFactoryBean initProcessEngines() {
		MethodInvokingFactoryBean a = new MethodInvokingFactoryBean();
		a.setStaticMethod("org.activiti.engine.ProcessEngines.init");
		return a;
	}

	@Bean
	@DependsOn("initProcessEngines")
	public ProcessEngineFactoryBean processEngine() throws Throwable {
		ProcessEngineFactoryBean bean = new ProcessEngineFactoryBean();
		SpringProcessEngineConfiguration config = new SpringProcessEngineConfiguration();
		config.setDatabaseType("h2");
		config.setDataSource(dataSource());
		config.setTransactionManager(transactionManager());
		config.setDatabaseSchemaUpdate("null");
		config.setJobExecutorActivate(false);
		config
				.setDeploymentResources(new Resource[] { new ClassPathResource(
						"/org/yy/studyactiviti/bpmn/forkjoin.bpmn20.xml") });
		bean.setProcessEngineConfiguration(config);

		return bean;
	}


/*	<bean id="repositoryService" factory-bean="processEngine" factory-method="getRepositoryService" />
	<bean id="runtimeService" factory-bean="processEngine" factory-method="getRuntimeService" />
	<bean id="taskService" factory-bean="processEngine" factory-method="getTaskService" />
	<bean id="historyService" factory-bean="processEngine" factory-method="getHistoryService" />
	<bean id="managementService" factory-bean="processEngine" factory-method="getManagementService" />
*/
	@Bean
	public RepositoryService repositoryService() throws  Throwable{
		return processEngine().getObject().getRepositoryService();
	}
	@Bean
	public RuntimeService pruntimeService() throws  Throwable{
		return processEngine().getObject().getRuntimeService();
	}
	
	@Bean
	public TaskService taskService() throws  Throwable{
		return processEngine().getObject().getTaskService();
	}
	
	@Bean
	public HistoryService historyService() throws  Throwable{
		return processEngine().getObject().getHistoryService();
	}
	
	@Bean
	public ManagementService managementService() throws  Throwable{
		return processEngine().getObject().getManagementService();
	}
}
