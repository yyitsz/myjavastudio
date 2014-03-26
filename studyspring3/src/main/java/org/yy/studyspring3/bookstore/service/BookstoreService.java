package org.yy.studyspring3.bookstore.service;

import java.util.List;

import org.yy.studyspring3.bookstore.domain.Book;



public interface BookstoreService {

    List<Book> search(BookSearchCriteria criteria);

    Book findBook(long bookId);

}
