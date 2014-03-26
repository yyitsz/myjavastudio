/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package org.yy.studyapp.common.model;

import java.math.BigDecimal;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;
import org.yy.studyapp.core.model.BaseEntity;

/**
 *
 * @author yyi
 */
@Entity
@Table(name="ORDER")
public class Order extends BaseEntity<Order,Long>{
    @Id
    private Long id;
    private String instrumentCode;
    private BigDecimal lot;
    private BigDecimal price;
    private String accountId;
    
    @Override
    public Long getPK() {
        return id;
    }

    public String getAccountId() {
        return accountId;
    }

    public void setAccountId(String accountId) {
        this.accountId = accountId;
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getInstrumentCode() {
        return instrumentCode;
    }

    public void setInstrumentCode(String instrumentCode) {
        this.instrumentCode = instrumentCode;
    }

    public BigDecimal getLot() {
        return lot;
    }

    public void setLot(BigDecimal lot) {
        this.lot = lot;
    }

    public BigDecimal getPrice() {
        return price;
    }

    public void setPrice(BigDecimal price) {
        this.price = price;
    }
    
    
}
