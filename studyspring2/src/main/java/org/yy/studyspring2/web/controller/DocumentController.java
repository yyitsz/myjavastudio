package org.yy.studyspring2.web.controller;

import java.io.IOException;
import java.io.OutputStream;
import java.sql.Blob;
import java.sql.SQLException;

import javax.servlet.http.HttpServletResponse;

import org.h2.util.IOUtils;
import org.hibernate.Hibernate;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.multipart.MultipartFile;
import org.springframework.web.servlet.ModelAndView;
import org.yy.studyspring2.model.Document;
import org.yy.studyspring2.services.impl.DocumentService;

@Controller
public class DocumentController {
	@Autowired
	private DocumentService docService;

	@RequestMapping(value = "/doc/index")
	public ModelAndView index() {
		ModelAndView mv = new ModelAndView("documents");
		mv.addObject("document", new Document());
		mv.addObject("documentList", docService.getAll());
		return mv;
	}

	@RequestMapping(value = "/doc/save", method = RequestMethod.POST)
	public String save(@ModelAttribute("document") Document document,
			@RequestParam("file") MultipartFile file) throws IOException {
		System.out.println("Document Info:");
		System.out.println(document);
		Blob blob = Hibernate.createBlob(file.getInputStream());
		document.setFileName(file.getOriginalFilename());
		document.setContent(blob);
		document.setContentType(file.getContentType());

		docService.save(document);

		return "redirect:/doc/index.html";
	}

	@RequestMapping(value = "/doc/download/{id}")
	@Transactional
	public void download(@PathVariable("id") Long id,
			HttpServletResponse response) throws IOException, SQLException {
		Document doc = docService.get(id);
		response.setHeader("Content-Disposition", "inline;filename=\""
				+ doc.getFileName() + "\"");
		OutputStream out = response.getOutputStream();
		response.setContentType(doc.getContentType());
		IOUtils.copy(doc.getContent().getBinaryStream(), out);
		out.flush();
		out.close();

	}

	@RequestMapping(value = "/doc/delete/{id}")
	public String delete(@PathVariable("id") Long id) {
		docService.delete(id);

		return "redirect:/doc/index.html";
	}
}
