import { Component, OnInit } from '@angular/core';
import { Courses } from 'src/app/mock-courses';
@Component({
  selector: 'app-student-home',
  templateUrl: './student-home.component.html',
  styleUrls: ['./student-home.component.css']
})
export class StudentHomeComponent implements OnInit {

  courses = Courses;
  constructor() { }

  ngOnInit(): void {
  }

}
