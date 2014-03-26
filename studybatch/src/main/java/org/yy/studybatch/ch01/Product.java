/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package org.yy.studybatch.ch01;

import java.math.BigDecimal;

/**
 *
 * @author yyi
 */
public class Product {
    private String id;
    private String name;
    private String description;
    private BigDecimal price;

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public BigDecimal getPrice() {
        return price;
    }

    public void setPrice(BigDecimal price) {
        this.price = price;
    }
    
    
    
}
