package org.yy.studymybatis.mapper;

import java.util.List;

import org.yy.studymybatis.model.Author;

public interface AuthorMapper {
	public List<Author> findAll();
    public Author findById(Integer id);
    public void insert(Author author);
    public void update(Author author);
    public void deleteById(Integer id);
	public void delete(Author author);
}