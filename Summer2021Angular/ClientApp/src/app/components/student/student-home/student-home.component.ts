import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-student-home',
  templateUrl: './student-home.component.html',
  styleUrls: ['./student-home.component.css']
})
export class StudentHomeComponent implements OnInit {

  classes = [
    {
      'name': 'GBIO',
      'teacher': 'sss',
      'description': 'wwww'
    },
    {
      'name': 'BIO',
      'teacher': 'ccc',
      'description': 'weeewww'
    },
    {
      'name': 'CALC',
      'teacher': 'sss',
      'description': 'wwww'
    },
    {
      'name': 'CMPS',
      'teacher': 'rrr',
      'description': 'ttt'
    }
  ];

  constructor() { }

  ngOnInit(): void {
  }

}
