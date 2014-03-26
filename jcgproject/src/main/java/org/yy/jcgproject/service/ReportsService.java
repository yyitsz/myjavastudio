package org.yy.jcgproject.service;


import java.util.List;

import org.yy.jcgproject.domain.Reports;

public interface ReportsService {
	public void initReports(int maxNumbers);
	public List<Reports> getReports();

}
