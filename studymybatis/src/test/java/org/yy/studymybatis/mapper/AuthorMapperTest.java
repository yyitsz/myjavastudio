package org.yy.studymybatis.mapper;

import java.util.List;
import java.util.UUID;

import junit.framework.Assert;

import org.junit.Test;
import org.yy.studymybatis.model.Author;
import org.yy.studymybatis.util.MapperAction;
import org.yy.studymybatis.util.MapperActionNoResult;
import org.yy.studymybatis.util.SessionHelper;

public class AuthorMapperTest {

	@Test
	public void crudTest() {

		final Author author = new Author();
		author.setName("Author_1"+ Long.toString(System.currentTimeMillis()));
		author.setEmail("Author_1@mail.com"+ Long.toString(System.currentTimeMillis()));
		
		// insert
		SessionHelper.execute(AuthorMapper.class,
				new MapperActionNoResult<AuthorMapper>() {

					@Override
					public void execute(AuthorMapper mapper) {

						mapper.insert(author);
					}

				});

		Assert.assertTrue(author.getId() > 0);
		// findById
		final Author savedTag = SessionHelper.execute(AuthorMapper.class,
				new MapperAction<AuthorMapper, Author>() {

					@Override
					public Author execute(AuthorMapper mapper) {

						return mapper.findById(author.getId());
					}

				});

		Assert.assertNotNull(savedTag);
		Assert.assertEquals(author.getName(), savedTag.getName());

		// update
		author.setName("Author_2"+ Long.toString(System.currentTimeMillis()));
		author.setEmail("Author_2@mail.com"+ Long.toString(System.currentTimeMillis()));
		
		SessionHelper.execute(AuthorMapper.class,
				new MapperActionNoResult<AuthorMapper>() {

					@Override
					public void execute(AuthorMapper mapper) {

						mapper.update(savedTag);
					}

				});

		final Author savedAuthor2 = SessionHelper.execute(AuthorMapper.class,
				new MapperAction<AuthorMapper, Author>() {

					@Override
					public Author execute(AuthorMapper mapper) {

						return mapper.findById(savedTag.getId());
					}

				});

		Assert.assertNotNull(savedAuthor2);
		Assert.assertEquals(savedTag.getName(), savedAuthor2.getName());
		
		//FindAll
		final List<Author> tagList = SessionHelper.execute(AuthorMapper.class,
				new MapperAction<AuthorMapper,List<Author>>() {

					@Override
					public List<Author> execute(AuthorMapper mapper) {

						return mapper.findAll();
					}

				});
		
		Assert.assertTrue(tagList.size() > 0);
		
		//delete
		SessionHelper.execute(AuthorMapper.class,
				new MapperActionNoResult<AuthorMapper>() {

					@Override
					public void execute(AuthorMapper mapper) {

						mapper.delete(savedTag);
					}

				});
		
		final Author deletedTag = SessionHelper.execute(AuthorMapper.class,
				new MapperAction<AuthorMapper, Author>() {

					@Override
					public Author execute(AuthorMapper mapper) {

						return mapper.findById(savedTag.getId());
					}

				});
		
		Assert.assertNull(deletedTag);
	}
}
