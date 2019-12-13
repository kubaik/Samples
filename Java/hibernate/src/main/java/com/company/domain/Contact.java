package com.company.domain;

import javax.persistence.Entity;
import javax.persistence.Id;
import java.net.URL;

@Entity(name = "Contact")
public class Contact {
    @Id
    private Integer id;

    private Name name;

    private String notes;

    private URL website;

    private boolean starred;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Name getName() {
        return name;
    }

    public void setName(Name name) {
        this.name = name;
    }

    public String getNotes() {
        return notes;
    }

    public void setNotes(String notes) {
        this.notes = notes;
    }

    public URL getWebsite() {
        return website;
    }

    public void setWebsite(URL website) {
        this.website = website;
    }

    //Getters and setters are omitted for brevity
}
