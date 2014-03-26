/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package org.yy.studybatch.ch01.batch;

import java.math.BigDecimal;
import org.springframework.batch.item.file.mapping.FieldSetMapper;
import org.springframework.batch.item.file.transform.FieldSet;
import org.springframework.validation.BindException;
import org.yy.studybatch.ch01.Product;

/**
 *
 * @author yyi
 */
public class ProductFieldSetMapper implements FieldSetMapper<Product> {

    @Override
    public Product mapFieldSet(FieldSet fs) throws BindException {
        Product p = new Product();
        p.setId(fs.readString("PRODUCT_ID"));
        p.setName(fs.readString("NAME"));
        p.setDescription(fs.readString("DESCRIPTION"));
        p.setPrice(fs.readBigDecimal("PRICE"));
        return p;
    }
    
}
