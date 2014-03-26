package org.yy.studymybatis.mapper;

import java.util.List;

import org.yy.studymybatis.model.Post;

public interface PostMapper {
	public List<Post> findAll();
    public Post findById(Integer id);
    public void insert(Post post);
    public void update(Post post);
    public void deleteById(Integer id);
	public void delete(Post post);
}