package com.app.MVCApp.controllers;

import com.app.MVCApp.models.User;
import com.app.MVCApp.services.UserService;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;

import java.util.Optional;

@Controller
public class SearchController {


    @GetMapping("/result")
    public String result(Model model, String phone_number, String full_name, String passport_data) {
        UserService userService = new UserService();
        Optional<User> user = Optional.ofNullable(userService.findBy(phone_number, full_name,
                Integer.parseInt(passport_data)));
        user.ifPresent(User -> model.addAttribute("user", User));

        return "result";
    }

    @PostMapping("/search")
    public String homeAdd(@RequestParam String phone_number, @RequestParam String full_name,
                          @RequestParam String passport_data, Model model) {

        result(model, phone_number, full_name, passport_data);

        return "result";
    }

    @GetMapping("/search")
    public String search(Model model) {
        model.addAttribute("tittle", "tittle");
        return "search";
    }

}
