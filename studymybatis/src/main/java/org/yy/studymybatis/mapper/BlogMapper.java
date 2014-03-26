package org.yy.studymybatis.mapper;

import java.util.List;

import org.yy.studymybatis.model.Blog;

public interface BlogMapper {
	public List<Blog> findAll();
    public Blog findById(Integer id);
    public void insert(Blog blog);
    public void update(Blog blog);
    public void deleteById(Integer id);
	public void delete(Blog blog);
}