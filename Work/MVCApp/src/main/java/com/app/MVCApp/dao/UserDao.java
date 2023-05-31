package com.app.MVCApp.dao;


import com.app.MVCApp.models.User;
import org.hibernate.Session;
import org.hibernate.Transaction;
import com.app.MVCApp.utils.HibernateSessionFactoryUtil;
import java.util.List;
import java.util.Optional;

public class UserDao {

    //public User findById(long id) {
    //    return HibernateSessionFactoryUtil.getSessionFactory().openSession().get(User.class, id);
    //}

    public User findById(long id) {
        int ID = (int)id;
        User user = (User) HibernateSessionFactoryUtil.getSessionFactory().openSession()
                .createQuery(String.format("From User where id = %d",ID), User.class).uniqueResult();
        //return HibernateSessionFactoryUtil.getSessionFactory().openSession().get(User.class, id);
        return user;
    }

    public User findByInfo(String phone_number, String full_name, int passport_data) {
        User user = (User) HibernateSessionFactoryUtil.getSessionFactory().openSession()
                .createQuery(String.format("From User where phone_number = '%s' and full_name = '%s' and passport_data = %d",
                        phone_number, full_name, passport_data), User.class).uniqueResult();
        //return HibernateSessionFactoryUtil.getSessionFactory().openSession().get(User.class, id);
        return user;
    }


    public void save(User user) {
        Session session = HibernateSessionFactoryUtil.getSessionFactory().openSession();
        Transaction tx1 = session.beginTransaction();
        session.save(user);
        tx1.commit();
        session.close();
    }

    public void update(User user) {
        Session session = HibernateSessionFactoryUtil.getSessionFactory().openSession();
        Transaction tx1 = session.beginTransaction();
        session.update(user);
        tx1.commit();
        session.close();
    }

    public List<User> findAll() {
        List<User> users = (List<User>) HibernateSessionFactoryUtil.getSessionFactory().openSession().createQuery("From User").list();
        return users;
    }

    public List<User> findAllApproved() {
        List<User> users = (List<User>) HibernateSessionFactoryUtil.getSessionFactory().openSession().createQuery(String.format("From User where approved = 'Одобрен'")).list();
        return users;
    }

    public List<User> findAllSigned() {
        List<User> users = (List<User>) HibernateSessionFactoryUtil.getSessionFactory().openSession().createQuery(String.format("From User where signed = 'Подписан'")).list();
        return users;
    }
}
