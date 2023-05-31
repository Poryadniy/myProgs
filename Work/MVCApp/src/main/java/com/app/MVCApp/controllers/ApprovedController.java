package com.app.MVCApp.controllers;

import com.app.MVCApp.models.User;
import com.app.MVCApp.services.UserService;
import org.springframework.ui.Model;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;

import java.util.Optional;

@Controller
public class ApprovedController {

    private UserService userService = new UserService();

    @GetMapping("/sign_contract")
    public String sign(Model model) {
        Iterable<User> users = userService.findAllUsers();
        model.addAttribute("users", users);
        return "sign_contract";
    }

    @GetMapping("/sign_contract/{id}")
    public String sign_id(@PathVariable(value = "id") long id, Model model) {
        Optional<User> user = Optional.ofNullable(userService.findUser(id));
        user.ifPresent(User -> model.addAttribute("user", User));
        return "sign_contract";
    }

    @PostMapping("/sign_contract/{id}")
    public String signed(@PathVariable(value = "id") long id, Model model) {

        User user = userService.findUser(id);
        UserService userService = new UserService();

        user.setSigned("Подписан");
        userService.updateUser(user);

        return "redirect:/home";
    }
}
