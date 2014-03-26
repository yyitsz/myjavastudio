package org.yy.obfuscation.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.yy.obfuscation.model.User;

public interface UserRepository extends JpaRepository<User, Long>{

}
