import { Injectable } from '@angular/core';
import { Course } from '../interfaces/course';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor(private http: HttpClient) { }

  private coursesUrl = 'https://localhost:44325/api/Courses'

  getCourses(): Observable<Course[]> {
    return this.http.get<Course[]>(this.coursesUrl)
  }
}
