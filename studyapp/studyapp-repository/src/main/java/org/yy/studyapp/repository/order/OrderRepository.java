/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package org.yy.studyapp.repository.order;

import org.springframework.data.jpa.repository.JpaRepository;
import org.yy.studyapp.common.model.Order;

/**
 *
 * @author yyi
 */
public interface OrderRepository extends JpaRepository<Order, Long> {
    
}
