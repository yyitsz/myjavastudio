package org.yy.core.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import org.yy.core.model.Person;

import java.util.List;

/**
 * Created by yyi on 2017/3/15.
 */
@Repository
public interface PersonRepo extends JpaRepository<Person, Long> {
    @Query("select p from Person p where p.firstName = :firstName")
    List<Person> findByName(@Param("firstName") String firstName);
}
