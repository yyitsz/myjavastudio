/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package org.yy.studyapp.core.model;

import java.io.Serializable;
import java.util.Date;
import javax.persistence.MappedSuperclass;
import javax.persistence.PrePersist;
import javax.persistence.PreUpdate;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.persistence.Version;

/**
 *
 * @author yyi
 */
@MappedSuperclass
public abstract class BaseEntity<TM extends BaseEntity<TM,TId>,TId extends Serializable> implements Serializable {
    @Version
    private Long version;
    private String createdBy;
    @Temporal(TemporalType.TIME)
    private Date createdAt;
    private String updatedBy;
     @Temporal(TemporalType.TIME)
    private Date updatedAt;

    public abstract TId getPK();
     
    public Date getCreatedAt() {
        return createdAt;
    }

    public void setCreatedAt(Date createdAt) {
        this.createdAt = createdAt;
    }

    public String getCreatedBy() {
        return createdBy;
    }

    public void setCreatedBy(String createdBy) {
        this.createdBy = createdBy;
    }

    public Date getUpdatedAt() {
        return updatedAt;
    }

    public void setUpdatedAt(Date updatedAt) {
        this.updatedAt = updatedAt;
    }

    public String getUpdatedBy() {
        return updatedBy;
    }

    public void setUpdatedBy(String updatedBy) {
        this.updatedBy = updatedBy;
    }

    public Long getVersion() {
        return version;
    }

    public void setVersion(Long version) {
        this.version = version;
    }

    @Override
    public boolean equals(Object obj) {
        if (obj == null) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        final BaseEntity<TM, TId> other = (BaseEntity<TM, TId>) obj;
        TId myId = getPK();
        TId yourId = other.getPK();
        if(myId == null || yourId == null){
            return false;
        }
        return myId.equals(yourId);
    }

    @Override
    public int hashCode() {

        TId myId = getPK();

        if(myId == null ){
            return this.hashCode();
        }
        return myId.hashCode();
    }
    @PrePersist
    public void auditForPersistion(){
        this.createdAt = new Date(System.currentTimeMillis());
    }
    
    @PreUpdate
    public void auditForUpdate(){
        this.updatedAt = new Date(System.currentTimeMillis());
    }
    
}
