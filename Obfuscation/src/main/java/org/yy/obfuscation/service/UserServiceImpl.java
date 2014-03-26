package org.yy.obfuscation.service;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.yy.obfuscation.model.Profile;
import org.yy.obfuscation.model.User;
import org.yy.obfuscation.repository.ProfileRepository;
import org.yy.obfuscation.repository.UserRepository;

@Service
public class UserServiceImpl implements UserService {
	@Resource
	private UserRepository userRepo;
	
	@Resource
	private ProfileRepository profileRepo;
	
	@Transactional
	public void saveUser(User user){
		userRepo.save(user);
	}
	@Transactional
	public void deleteUser(User user){
		
		List<Profile> profiles = profileRepo.findProfilesByUserId(user.getId());
		profileRepo.delete(profiles);
		userRepo.delete(user);
	}
	@Transactional
	public void saveProfile(Profile profile){
		profileRepo.save(profile);
	}
	@Transactional
	public void deleteProfile(Profile profile){
		profileRepo.delete(profile);
	}
}
