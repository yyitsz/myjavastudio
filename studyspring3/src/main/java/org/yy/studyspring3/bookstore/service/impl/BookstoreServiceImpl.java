package org.yy.studyspring3.bookstore.service.impl;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;

import org.springframework.stereotype.Service;
import org.yy.studyspring3.bookstore.domain.Book;
import org.yy.studyspring3.bookstore.service.BookSearchCriteria;
import org.yy.studyspring3.bookstore.service.BookstoreService;
@Service
public class BookstoreServiceImpl implements BookstoreService {

    ArrayList<Book> books = new ArrayList<Book>();
    
    
    
    public BookstoreServiceImpl() {
        initBookStore();
    }

    private void initBookStore() {
        
        Book b = new Book();
        b.setId(1);
        b.setTitle("Programmer");
        b.setDescription("good book.");
        b.setPrice(new BigDecimal("89.00"));
        b.setYear(2010);
        b.setAuthor("zhange");
        b.setIsbn("ISBN-1212121-121");
        books.add(b);
        
        b = new Book();
        b.setId(2);
        b.setTitle("Programmer2");
        b.setDescription("good book.");
        b.setPrice(new BigDecimal("389.00"));
        b.setYear(2010);
        b.setAuthor("zhange");
        b.setIsbn("ISBN-1212121-121");
        books.add(b);
        
        
        b = new Book();
        b.setId(3);
        b.setTitle("Programmer3");
        b.setDescription("good book.");
        b.setPrice(new BigDecimal("289.00"));
        books.add(b);
        b.setYear(2010);
        b.setAuthor("zhange");
        b.setIsbn("ISBN-1212121-121");
        
        b = new Book();
        b.setId(4);
        b.setTitle("Programmer4");
        b.setDescription("good book.");
        b.setPrice(new BigDecimal("189.00"));
        b.setYear(2010);
        b.setAuthor("zhange");
        b.setIsbn("ISBN-1212121-121");
        books.add(b);
        
    }

    @Override
    public List<Book> search(BookSearchCriteria criteria) {
       
        return books;
    }

    @Override
    public Book findBook(long bookId) {
        for(Book b : books){
            if(b.getId() == bookId){
                return b;
            }
        }
        return null;
    }

}
