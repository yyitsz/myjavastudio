<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@taglib prefix="spring" uri="http://www.springframework.org/tags" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
   "http://www.w3.org/TR/html4/loose.dtd">

	
<html>
<head>
 <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Search</title>
</head>
<body>
	<form action="<c:url value="/book/search" />" method="post">
		<fieldset>
			<legend>Search Criteria</legend>
			<table>
				<tr>
					<td>Title</td>
					<td>
						<input type="text" id="title" name="title" placeholder="Title" />
					</td>
				</tr>
				<tr>
					<td>Price</td>
					<td>
						<input type="text" id="price" name="price" placeholder="Price" />
					</td>					
				</tr>
				<tr>
					<td colspan="2" align="center">
						<button id="search">Search</button>
					</td>
				</tr>
			</table>
		</fieldset>
	</form>
	
	<c:if test="${not empty bookList}">
		<table>
			<thead>
				<tr>
				<th>Title</th><th>Description</th><th>Price</th>
				</tr>
			</thead>
			<c:forEach items="${bookList}" var="book">
				<tr>
					<td><a href="<c:url value="/book/detail/${book.id}" />"> ${book.title}</a></td>
					<td>${book.description }</td>
					<td>${book.price }</td>
				</tr>
				
			</c:forEach>
		</table>
	</c:if>
</body>
</html>