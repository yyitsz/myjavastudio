package org.yy.obfuscation.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.yy.obfuscation.model.Profile;

public interface ProfileRepository extends JpaRepository<Profile, Long>{

	@Query("select p.* from Profile p.user.id=:userId")
	List<Profile> findProfilesByUserId(@Param("userId") Long userId);
}
