/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package org.yy.studyapp.common.dto.order;

import java.math.BigDecimal;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 *
 * @author yyi
 */
@XmlRootElement()
//@XmlType(name="OrderDto", namespace="http://studyapp.org/order")
@XmlAccessorType(XmlAccessType.FIELD)
public class OrderDto {

    @XmlElement
    private Long id;
    @XmlElement
    private String instrumentCode;
    @XmlElement
    private BigDecimal lot;
    @XmlElement
    private BigDecimal price;
    @XmlElement
    private String accountId;

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

    @Override
    public String toString() {
        return "OrderDto{" + "id=" + id + ", instrumentCode=" + instrumentCode + ", lot=" + lot + ", price=" + price + ", accountId=" + accountId + '}';
    }
    
    
}
