package org.yy.studymybatis.mapper;

import java.util.List;

import org.yy.studymybatis.model.Tag;

public interface TagMapper {
	public List<Tag> findAll();
    public Tag findById(Integer id);
    public void insert(Tag tag);
    public void update(Tag tag);
    public void deleteById(Integer id);
	public void delete(Tag tag);
}