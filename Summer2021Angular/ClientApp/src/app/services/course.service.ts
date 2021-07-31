import { Injectable } from '@angular/core';
import { Course } from '../interfaces/course';
import { Courses } from '../mock-courses';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor() { }

  getCourses(): Observable<Course[]> {
    const courses = of(Courses);
    return courses;
  }
}
