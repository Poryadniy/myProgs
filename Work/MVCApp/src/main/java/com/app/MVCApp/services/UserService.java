package com.app.MVCApp.services;

import com.app.MVCApp.models.User;
import com.app.MVCApp.dao.UserDao;
import java.util.List;
import java.util.Optional;

public class UserService {

    private UserDao usersDao = new UserDao();

    public UserService() {
    }

    public User findUser(long id) {
        return usersDao.findById(id);
    }

    public User findBy(String phone_number, String full_name, int passport_data) {
        return usersDao.findByInfo(phone_number, full_name, passport_data);
    }

    public void saveUser(User user) {
        usersDao.save(user);
    }

    public void updateUser(User user) {
        usersDao.update(user);
    }

    public List<User> findAllUsers() {
        return usersDao.findAll();
    }

    public List<User> findApproved() {
        return usersDao.findAllApproved();
    }

    public List<User> findSigned() {
        return usersDao.findAllSigned();
    }
}
