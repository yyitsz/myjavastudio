<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<%@taglib prefix="spring" uri="http://www.springframework.org/tags"%>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
   "http://www.w3.org/TR/html4/loose.dtd">


<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Search</title>
</head>
<body>

	
	<c:if test="${not empty book}">
	<c:url value="/resources/images/book/${book.isbn}/book_front_conver.png" var="bookImg" />
	<img alt="${book.title}" src="${bookImg} }" width="250" align="left" />
		<table>
			<tr>
				<td>Title</td>
				<td>${book.title}</a></td>
			</tr>
			<tr>
				<td>Description</td>
				<td>${book.description}</a></td>
			</tr>
			<tr>
				<td>Price</td>
				<td>${book.price}</a></td>
			</tr>
			<tr>
				<td>ISBN</td>
				<td>${book.isbn}</a></td>
			</tr>
			<tr>
				<td>year</td>
				<td>${book.year}</a></td>
			</tr>
			<tr>
				<td>author</td>
				<td>${book.author}</a></td>
			</tr>
		</table>
	</c:if>
	<c:if test="empty book">
		Not found book.
	</c:if>
</body>
</html>