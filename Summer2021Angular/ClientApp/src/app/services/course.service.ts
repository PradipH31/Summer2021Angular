import { Injectable } from '@angular/core';
import { Course } from '../interfaces/course';
import { Courses } from '../mock-courses';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor() { }

  getCourses(): Course[] {
    return Courses;
  }
}
