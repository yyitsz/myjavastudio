package org.yy.studymybatis.mapper;

import java.util.List;
import java.util.UUID;

import junit.framework.Assert;

import org.apache.ibatis.session.SqlSession;
import org.junit.Test;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.yy.studymybatis.model.Author;
import org.yy.studymybatis.model.Blog;
import org.yy.studymybatis.model.Post;
import org.yy.studymybatis.util.MapperAction;
import org.yy.studymybatis.util.MapperActionNoResult;
import org.yy.studymybatis.util.SessionActionNoResult;
import org.yy.studymybatis.util.SessionHelper;

public class PostMapperTest {
	final private Logger logger = LoggerFactory.getLogger(PostMapperTest.class);
	@Test
	public void crudTest() {

		final Author author = new Author();
		author.setEmail("TEST_EMIALI@ABCFDASD.com.test"+ Long.toString(System.currentTimeMillis()));
		author.setName("author$#$#$#$@"+ Long.toString(System.currentTimeMillis()));
		
		final Blog blog = new Blog();
		blog.setAuthor(author);
		blog.setName("$%$%MyBlogForTestingPost"+ Long.toString(System.currentTimeMillis()));
		blog.setUrl("/$%$%MyBlogForTestingPost"+ Long.toString(System.currentTimeMillis()));
		final Post post = new Post();
		post.setTitle("PostTitle");
		logger.debug("**************Insert Author, Blog, Post.");
		// insert
		SessionHelper.execute(new SessionActionNoResult() {

					@Override
					public void execute(SqlSession session) {
						BlogMapper bm = session.getMapper(BlogMapper.class);
						PostMapper pm = session.getMapper(PostMapper.class);
						AuthorMapper am = session.getMapper(AuthorMapper.class);
						logger.debug("**************Insert Author");
						am.insert(author);
						logger.debug("**************Insert Blog.");
						bm.insert(blog);
						logger.debug("**************Insert  Post.");
						post.setBlog(blog);
						pm.insert(post);
					}

				});

		logger.debug("**************Find Post to check if inserted. ");
		Assert.assertTrue(post.getId() > 0);
		// findById
		final Post savedPost = SessionHelper.execute(PostMapper.class,
				new MapperAction<PostMapper, Post>() {

					@Override
					public Post execute(PostMapper mapper) {

						return mapper.findById(post.getId());
					}

				});

		Assert.assertNotNull(savedPost);

		logger.debug("**************Check Blog in Post ");
		Assert.assertNotNull(savedPost.getBlog());
		Assert.assertEquals(blog.getId(), savedPost.getBlog().getId());
		logger.debug("**************Check author in Blog in Post ");
		Assert.assertNotNull(savedPost.getBlog().getAuthor());
		Assert.assertEquals(author.getId(), savedPost.getBlog().getAuthor().getId());
		Assert.assertEquals(post.getTitle(), savedPost.getTitle());

		logger.debug("**************Update Post ");
		// update
		savedPost.setTitle("ModifiedTitle"+ Long.toString(System.currentTimeMillis()));
		SessionHelper.execute(PostMapper.class,
				new MapperActionNoResult<PostMapper>() {

					@Override
					public void execute(PostMapper mapper) {

						mapper.update(savedPost);
					}

				});

		final Post savedPost2 = SessionHelper.execute(PostMapper.class,
				new MapperAction<PostMapper, Post>() {

					@Override
					public Post execute(PostMapper mapper) {

						return mapper.findById(savedPost.getId());
					}

				});

		Assert.assertNotNull(savedPost2);
		Assert.assertEquals(savedPost.getTitle(), savedPost2.getTitle());
		
		logger.debug("**************Find all Posts ");
		//FindAll
		final List<Post> tagList = SessionHelper.execute(PostMapper.class,
				new MapperAction<PostMapper,List<Post>>() {

					@Override
					public List<Post> execute(PostMapper mapper) {

						return mapper.findAll();
					}

				});
		
		Assert.assertTrue(tagList.size() > 0);
		
		logger.debug("**************delete  Post ");
		//delete
		SessionHelper.execute(new SessionActionNoResult() {

			@Override
			public void execute(SqlSession session) {
				BlogMapper bm = session.getMapper(BlogMapper.class);
				PostMapper pm = session.getMapper(PostMapper.class);
				AuthorMapper am = session.getMapper(AuthorMapper.class);
				logger.debug("**************delete  Post ");
				pm.delete(post);
				logger.debug("**************delete  blog ");
				bm.delete(blog);
				logger.debug("**************delete  author ");
				am.delete(author);

			}

		});
		
		final Post deletedPost = SessionHelper.execute(PostMapper.class,
				new MapperAction<PostMapper, Post>() {

					@Override
					public Post execute(PostMapper mapper) {

						return mapper.findById(savedPost.getId());
					}

				});
		
		Assert.assertNull(deletedPost);
	}
}
