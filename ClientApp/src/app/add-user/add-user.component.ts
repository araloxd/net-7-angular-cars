import { Component, OnInit } from '@angular/core';
import { User } from '../models/User';
import { HttpClient } from '@angular/common/http';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit{
  newUser: User = {
    id: 0,
    username: '',
    email: ''
  };

  addUserForm = this.formBuilder.group({
    name: '',
    email: ''
  });

  userList: User[] = []; 

  constructor(private http: HttpClient,private formBuilder: FormBuilder) { }
  ngOnInit(): void {
    this.refreshUserList();
  }

  addUser() {
    this.http.post<User>('https://localhost:44427/api/users', this.newUser).subscribe(user => {
      console.log('User added:', user);
      this.refreshUserList();
    });
  }

  private refreshUserList(){
    this.http.get<User[]>('https://localhost:44427/api/users').subscribe((data) => {
      this.userList = data;
    });
  }
}