package org.yy.studymybatis.mapper;

import java.util.List;
import java.util.UUID;

import junit.framework.Assert;

import org.junit.Test;
import org.yy.studymybatis.model.Tag;
import org.yy.studymybatis.util.MapperAction;
import org.yy.studymybatis.util.MapperActionNoResult;
import org.yy.studymybatis.util.SessionHelper;

public class TagMapperTest {

	@Test
	public void crudTest() {

		final Tag tag = new Tag();
		tag.setValue("Tag2"+ Long.toString(System.currentTimeMillis()));
		// insert
		SessionHelper.execute(TagMapper.class,
				new MapperActionNoResult<TagMapper>() {

					@Override
					public void execute(TagMapper mapper) {

						mapper.insert(tag);
					}

				});

		Assert.assertTrue(tag.getId() > 0);
		// findById
		final Tag savedTag = SessionHelper.execute(TagMapper.class,
				new MapperAction<TagMapper, Tag>() {

					@Override
					public Tag execute(TagMapper mapper) {

						return mapper.findById(tag.getId());
					}

				});

		Assert.assertNotNull(savedTag);
		Assert.assertEquals(tag.getValue(), savedTag.getValue());

		// update
		savedTag.setValue("ModifiedTag"+ Long.toString(System.currentTimeMillis()));
		SessionHelper.execute(TagMapper.class,
				new MapperActionNoResult<TagMapper>() {

					@Override
					public void execute(TagMapper mapper) {

						mapper.update(savedTag);
					}

				});

		final Tag savedTag2 = SessionHelper.execute(TagMapper.class,
				new MapperAction<TagMapper, Tag>() {

					@Override
					public Tag execute(TagMapper mapper) {

						return mapper.findById(savedTag.getId());
					}

				});

		Assert.assertNotNull(savedTag2);
		Assert.assertEquals(savedTag.getValue(), savedTag2.getValue());
		
		//FindAll
		final List<Tag> tagList = SessionHelper.execute(TagMapper.class,
				new MapperAction<TagMapper,List<Tag>>() {

					@Override
					public List<Tag> execute(TagMapper mapper) {

						return mapper.findAll();
					}

				});
		
		Assert.assertTrue(tagList.size() > 0);
		
		//delete
		SessionHelper.execute(TagMapper.class,
				new MapperActionNoResult<TagMapper>() {

					@Override
					public void execute(TagMapper mapper) {

						mapper.delete(savedTag);
					}

				});
		
		final Tag deletedTag = SessionHelper.execute(TagMapper.class,
				new MapperAction<TagMapper, Tag>() {

					@Override
					public Tag execute(TagMapper mapper) {

						return mapper.findById(savedTag.getId());
					}

				});
		
		Assert.assertNull(deletedTag);
	}
}
