package org.yy.studymybatis.mapper;

import java.util.List;

import org.apache.ibatis.annotations.Delete;
import org.apache.ibatis.annotations.Insert;
import org.apache.ibatis.annotations.Options;
import org.apache.ibatis.annotations.Result;
import org.apache.ibatis.annotations.Results;
import org.apache.ibatis.annotations.Select;
import org.apache.ibatis.annotations.Update;
import org.yy.studymybatis.model.Contact;

public interface ContactMapper {
//	@Select("SELECT * FROM CONTACT")
//	@Results(value = { @Result(property = "id"),
//			@Result(property = "name", column = "CONTACT_NAME"),
//			@Result(property = "phone", column = "CONTACT_PHONE"),
//			@Result(property = "email", column = "CONTACT_EMAIL") })
	List<Contact> selectAll();

//	@Select("SELECT * FROM CONTACT WHERE CONTACT_ID=#{id}")
//	@Results(value = { @Result(property = "id"),
//			@Result(property = "name", column = "CONTACT_NAME"),
//			@Result(property = "phone", column = "CONTACT_PHONE"),
//			@Result(property = "email", column = "CONTACT_EMAIL") })
	Contact selectById(int id);

	//@Update("UPDATE CONTACT SET CONTACT_EMAIL = #{email}, CONTACT_NAME = #{name}, CONTACT_PHONE= #{phone} WHERE CONTACT_ID=#{id}")
	void update(Contact contact);

//	@Insert("INSERT into CONTACT(CONTACT_EMAIL, CONTACT_NAME, CONTACT_PHONE) VALUES(#{email},#{name},#{phone})")
//	@Options(useGeneratedKeys = true, keyProperty = "id")
	void insert(Contact contact);
	//@Delete("DELETE FROM CONTACT WHERE CONTACT_ID=#{id}")
	void deleteById(int id);
	
	void delete(Contact contact);
}
