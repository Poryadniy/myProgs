package com.app.MVCApp.models;

import javax.persistence.*;
import java.util.ArrayList;
import java.util.List;

@Entity
@Table (name = "customers")

public class User {


    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private long id;

    private String full_name, marital_status, registration_address, phone_number, job_information, approved, signed, sign_date;
    private int passport_data, loan_ammount, loan_term;


    public User() {
    }

    public User(String full_name, int passport_data, String marital_status, String registration_address,
                String phone_number, String job_information, int loan_ammount, String approved, String signed, int loan_term, String sign_date) {
        this.full_name = full_name;
        this.passport_data = passport_data;
        this.marital_status = marital_status;
        this.registration_address = registration_address;
        this.phone_number = phone_number;
        this.job_information = job_information;
        this.loan_ammount = loan_ammount;
        this.approved = approved;
        this.signed = signed;
        this.loan_term = loan_term;
        this.sign_date = sign_date;
    }

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public String getFull_name() {
        return full_name;
    }

    public void setFull_name(String full_name) {
        this.full_name = full_name;
    }

    public String getMarital_status() {
        return marital_status;
    }

    public void setMarital_status(String marital_status) {
        this.marital_status = marital_status;
    }

    public String getRegistration_address() {
        return registration_address;
    }

    public void setRegistration_address(String registration_address) {
        this.registration_address = registration_address;
    }

    public String getPhone_number() {
        return phone_number;
    }

    public void setPhone_number(String phone_number) {
        this.phone_number = phone_number;
    }

    public String getJob_information() {
        return job_information;
    }

    public void setJob_information(String job_information) {
        this.job_information = job_information;
    }

    public int getPassport_data() {
        return passport_data;
    }

    public void setPassport_data(int passport_data) {
        this.passport_data = passport_data;
    }

    public int getLoan_ammount() {
        return loan_ammount;
    }

    public void setLoan_ammount(int loan_ammount) {
        this.loan_ammount = loan_ammount;
    }

    public String getApproved() {
        return approved;
    }

    public void setApproved(String approved) {
        this.approved = approved;
    }

    public String getSigned() {
        return signed;
    }

    public void setSigned(String signed) {
        this.signed = signed;
    }

    public int getLoan_term() { return loan_term; }

    public void setLoan_term(int loan_term) { this.loan_term = loan_term; }

    public String getSign_date() { return sign_date; }

    public void setSign_date(String sign_date) { this.sign_date = sign_date; }

}
