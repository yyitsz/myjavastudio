package org.yy.obfuscation.model;

import java.util.List;

import javax.persistence.CascadeType;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.JoinTable;
import javax.persistence.ManyToOne;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.persistence.Transient;

@Entity
@Table(name = "PROFILES")
public class Profile extends BaseModel {
	@Id
	@GeneratedValue(strategy = GenerationType.AUTO)
	private Long id;
	private String sourceFolder;
	private String destincationFolder;
	@OneToMany(cascade=CascadeType.ALL)
	@JoinTable(name = "PROFILE_ASSEMBLY", joinColumns = @JoinColumn(name = "PROFILE_ID"), inverseJoinColumns = @JoinColumn(name = "ASSEMBLY_ID"))
	private List<Assembly> assemblies;
	@ManyToOne
	private User user;

	@Transient
	private List<String> assemblyList;
	
	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getSourceFolder() {
		return sourceFolder;
	}

	public void setSourceFolder(String sourceFolder) {
		this.sourceFolder = sourceFolder;
	}

	public String getDestincationFolder() {
		return destincationFolder;
	}

	public void setDestincationFolder(String destincationFolder) {
		this.destincationFolder = destincationFolder;
	}

	public List<Assembly> getAssemblies() {
		return assemblies;
	}

	public void setAssemblies(List<Assembly> assemblies) {
		this.assemblies = assemblies;
	}

	public User getUser() {
		return user;
	}

	public void setUser(User user) {
		this.user = user;
	}

	public void setAssemblyList(List<String> assemblyList) {
		this.assemblyList = assemblyList;
	}

	public List<String> getAssemblyList() {
		return assemblyList;
	}

	@Override
	public String toString() {
		return "Profile [id=" + id + ", user=" + user + ", sourceFolder="
				+ sourceFolder + ", destincationFolder=" + destincationFolder
				+ ", assemblies=" + assemblies + ", assemblyList="
				+ assemblyList + "]";
	}

	

}
