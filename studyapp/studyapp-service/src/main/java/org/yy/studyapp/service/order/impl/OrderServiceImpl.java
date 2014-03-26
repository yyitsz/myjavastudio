/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package org.yy.studyapp.service.order.impl;

import java.util.List;
import javax.inject.Inject;
import org.springframework.stereotype.Service;
import org.yy.studyapp.common.model.Order;
import org.yy.studyapp.repository.order.OrderRepository;
import org.yy.studyapp.service.order.OrderService;

/**
 *
 * @author yyi
 */

@Service("orderService")
public class OrderServiceImpl implements OrderService {
    @Inject
    private OrderRepository orderRepo;
    
    public List<Order> findAll(){
        return orderRepo.findAll();
    }
    
}
