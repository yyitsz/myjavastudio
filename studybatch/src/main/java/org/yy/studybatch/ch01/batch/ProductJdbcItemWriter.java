/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package org.yy.studybatch.ch01.batch;

import java.util.List;
import javax.sql.DataSource;
import org.springframework.batch.item.ItemWriter;
import org.springframework.jdbc.core.simple.SimpleJdbcTemplate;
import org.yy.studybatch.ch01.Product;

/**
 *
 * @author yyi
 */
public class ProductJdbcItemWriter implements ItemWriter<Product> {

    private final String INSERT_SQL = "INSERT INTO products(id,name,desc,price) values(?,?,?,?)";
    private final String UPDATE_SQL = "UPDATE products SET name=?, desc=?, price=? WHERE id=?";
    private SimpleJdbcTemplate jdbcTemplate;

    public ProductJdbcItemWriter(DataSource dataSource) {
        jdbcTemplate = new SimpleJdbcTemplate(dataSource);
    }

    @Override
    public void write(List<? extends Product> items) throws Exception {

        for (Product product : items) {
            int count = jdbcTemplate.update(UPDATE_SQL, product.getName(), product.getDescription(), product.getPrice(), product.getId());
            if (count == 0) {
                jdbcTemplate.update(INSERT_SQL, product.getId(), product.getName(), product.getDescription(), product.getPrice());
            }
        }

    }
}
