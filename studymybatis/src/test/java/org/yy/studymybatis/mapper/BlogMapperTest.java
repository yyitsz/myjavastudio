package org.yy.studymybatis.mapper;

import java.util.List;
import java.util.UUID;

import junit.framework.Assert;

import org.junit.Test;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.yy.studymybatis.model.Blog;
import org.yy.studymybatis.util.MapperAction;
import org.yy.studymybatis.util.MapperActionNoResult;
import org.yy.studymybatis.util.SessionHelper;

public class BlogMapperTest {
	final private Logger logger = LoggerFactory.getLogger(BlogMapperTest.class);
	@Test
	public void crudTest() {

		final Blog blog = new Blog();
		blog.setName("MyBlog" + Long.toString(System.currentTimeMillis()));
		blog.setUrl("/myBlog"+ Long.toString(System.currentTimeMillis()));
		logger.debug("********** Insert Blog");
		// insert
		SessionHelper.execute(BlogMapper.class,
				new MapperActionNoResult<BlogMapper>() {

					@Override
					public void execute(BlogMapper mapper) {

						mapper.insert(blog);
					}

				});

		Assert.assertTrue(blog.getId() > 0);
		logger.debug("********** Find Blog to verify.");
		// findById
		final Blog savedBlog = SessionHelper.execute(BlogMapper.class,
				new MapperAction<BlogMapper, Blog>() {

					@Override
					public Blog execute(BlogMapper mapper) {

						return mapper.findById(blog.getId());
					}

				});

		Assert.assertNotNull(savedBlog);
		Assert.assertEquals(blog.getName(), savedBlog.getName());
		logger.debug("********** Check Posts in Blog.");
		Assert.assertNull(blog.getPosts());
		
		// update
		blog.setName("MyBlog2"+ Long.toString(System.currentTimeMillis()));
		blog.setUrl("/myBlog2"+ Long.toString(System.currentTimeMillis()));
		logger.debug("********** Update Blog.");
		SessionHelper.execute(BlogMapper.class,
				new MapperActionNoResult<BlogMapper>() {

					@Override
					public void execute(BlogMapper mapper) {

						mapper.update(savedBlog);
					}

				});

		final Blog savedBlog2 = SessionHelper.execute(BlogMapper.class,
				new MapperAction<BlogMapper, Blog>() {

					@Override
					public Blog execute(BlogMapper mapper) {

						return mapper.findById(savedBlog.getId());
					}

				});

		Assert.assertNotNull(savedBlog2);
		Assert.assertEquals(savedBlog.getName(), savedBlog2.getName());
		
		logger.debug("********** Find all Blogs.");
		//FindAll
		final List<Blog> blogList = SessionHelper.execute(BlogMapper.class,
				new MapperAction<BlogMapper,List<Blog>>() {

					@Override
					public List<Blog> execute(BlogMapper mapper) {

						return mapper.findAll();
					}

				});
		
		Assert.assertTrue(blogList.size() > 0);
		
		logger.debug("********** delete Blog.");
		//delete
		SessionHelper.execute(BlogMapper.class,
				new MapperActionNoResult<BlogMapper>() {

					@Override
					public void execute(BlogMapper mapper) {

						mapper.delete(savedBlog);
					}

				});
		
		final Blog deletedBlog = SessionHelper.execute(BlogMapper.class,
				new MapperAction<BlogMapper, Blog>() {

					@Override
					public Blog execute(BlogMapper mapper) {

						return mapper.findById(savedBlog.getId());
					}

				});
		
		Assert.assertNull(deletedBlog);
	}
}
