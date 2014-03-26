/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package org.yy.studybatch.ch01.batch;

import javax.inject.Inject;
import junit.framework.Assert;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.batch.core.Job;
import org.springframework.batch.core.JobParametersBuilder;
import org.springframework.batch.core.launch.JobLauncher;
import org.springframework.batch.core.repository.JobInstanceAlreadyCompleteException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.simple.SimpleJdbcTemplate;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

/**
 *
 * @author yyi
 */
@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(locations = {"classpath:import-products-job-context.xml", "classpath:test-context.xml"})
public class ImportProductsIntegrationTest {
    final String QUERY_COUNT_SQL = "SELECT count(1) FROM products";
    @Inject
    private JobLauncher jobLauncher;
    @Inject
    private SimpleJdbcTemplate jdbcTemplate;
    @Inject
    private Job importProducts;

    @Before
    public void setUp() {
        jdbcTemplate.update("DELETE FROM products");
        jdbcTemplate.update("INSERT INTO products(id,name,desc,price) values(?,?,?,?)", "PR....24","Nokia 2610","",102.3);
    }
    
    @Test
    public void importProducts() throws Exception{
        int initialCount = jdbcTemplate.queryForInt(QUERY_COUNT_SQL);
        jobLauncher.run(importProducts, new JobParametersBuilder()
                .addString("inputResource", "classpath:/input.zip")
                .addString("targetDirectory", "target/importProductsDir/")
                .addString("targetFile", "products.txt")
                .addLong("timestamp", System.currentTimeMillis())
                .toJobParameters());
        
        Assert.assertEquals(initialCount + 2, jdbcTemplate.queryForInt(QUERY_COUNT_SQL));
    }
}
