package org.yy.core.model;

import javax.persistence.*;

/**
 * Created by yyi on 2017/3/15.
 */
@Entity
@Table(name="IG_PERSON")
@Access(AccessType.FIELD)
public class Person {
    @Id
    @GeneratedValue(strategy =GenerationType.IDENTITY)
    private long id;
    @Column(name = "LAST_NAME")
    private String lastName;
    @Column(name = "FIRST_NAME")
    private String firstName;

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    @Override
    public String toString() {
        return "Person{" +
                "id=" + id +
                ", lastName='" + lastName + '\'' +
                ", firstName='" + firstName + '\'' +
                '}';
    }
}
