package net.saplobby.download;

public class ItpubAttachmentLink
        implements Comparable<ItpubAttachmentLink> {

    private String link;
    private String name;

    public String getLink() {
        return this.link;
    }

    public void setLink(String link) {
        this.link = link;
    }

    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        if (name.contains("&#039;")) {
            name = name.replace("&#039;", "'");
        }

        if (name.contains("\\")) {
            name = name.replace("\\", "");
        }
        this.name = name;
    }

    public ItpubAttachmentLink(String link, String name) {
        this.link = link;
        setName(name);
    }

    @Override
    public String toString() {
        return "ItpubAttachmentLink [link=" + this.link + ", name="
                + this.name + "]";
    }

    @Override
    public int hashCode() {
        int prime = 31;
        int result = 1;
        result = 31 * result + (this.link == null ? 0 : this.link.hashCode());
        result = 31 * result + (this.name == null ? 0 : this.name.hashCode());
        return result;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (obj == null) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        ItpubAttachmentLink other = (ItpubAttachmentLink) obj;
        if (this.link == null) {
            if (other.link != null) {
                return false;
            }
        } else if (!this.link.equals(other.link)) {
            return false;
        }
        if (this.name == null) {
            if (other.name != null) {
                return false;
            }
        } else if (!this.name.equals(other.name)) {
            return false;
        }
        return true;
    }

    @Override
    public int compareTo(ItpubAttachmentLink o) {
        return this.name.compareTo(o.name);
    }
}
