package com.app.MVCApp.controllers;

import com.app.MVCApp.models.User;
import com.app.MVCApp.services.UserService;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;

import java.time.LocalDate;
import java.util.Optional;


@Controller
public class MainController {

    private UserService userService = new UserService();

    @GetMapping("/home")
    public String home(Model model) {
        model.addAttribute("tittle", "tittle");
        return "home";
    }

    @PostMapping("/home")
    public String homeAdd(@RequestParam String full_name, @RequestParam String passport_data,
                          @RequestParam String marital_status, @RequestParam String registration_address,
                          @RequestParam String phone_number, @RequestParam String job_information,
                          @RequestParam String loan_ammount, @RequestParam String loan_term ,Model model) {


        User user = new User(full_name, Integer.parseInt(passport_data), marital_status, registration_address,
                phone_number, job_information, Integer.parseInt(loan_ammount),"Не одобрен","Не подписан",
                Integer.parseInt(loan_term) ,"-");
        userService.saveUser(user);

        int test = (int)decide(0,1);

        if (test == 0)
        {
            return String.format("redirect:/loan_unapproved/%d", user.getId());
        }
        else
        {
            LocalDate date = LocalDate.now();

            user.setApproved("Одобрен");
            userService.updateUser(user);
            user.setSign_date(""+date);
            userService.updateUser(user);
            return String.format("redirect:/loan_approved/%d", user.getId());
        }
    }

    @GetMapping("/loan_approved/{id}")
    public String loan_approwed(@PathVariable(value = "id") long id, Model model) {
        Optional<User> user = Optional.ofNullable(userService.findUser(id));
        user.ifPresent(User -> model.addAttribute("user", User));
        return "loan_approved";
    }

    @GetMapping("/loan_unapproved/{id}")
    public String loan_unapprowed(@PathVariable(value = "id") long id, Model model) {
        Optional<User> user = Optional.ofNullable(userService.findUser(id));
        user.ifPresent(User -> model.addAttribute("user", User));

        return "loan_unapproved";
    }


    @GetMapping("/all_clients")
    public String all_clients(Model model) {
        Iterable<User> users = userService.findAllUsers();
        model.addAttribute("users", users);
        return "all_clients";
    }


    @GetMapping("/approved")
    public String approved(Model model) {
        Iterable<User> users = userService.findApproved();
        model.addAttribute("users", users);
        return "approved";
    }

    @GetMapping("/signed")
    public String signed(Model model) {
        Iterable<User> users = userService.findSigned();
        model.addAttribute("users", users);
        return "signed";
    }


    public static double decide(double min, double max){
        double x = (int)(Math.random()*((max-min)+1))+min;
        return x;
    }
}
