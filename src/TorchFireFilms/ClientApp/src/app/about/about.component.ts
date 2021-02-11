import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss'],
})
export class AboutComponent implements OnInit {
  smScreen = false;
  mdScreen = false;

  constructor(private breakpointObserver: BreakpointObserver) {
    this.breakpointObserver
      .observe([Breakpoints.HandsetPortrait])
      .subscribe((result) => (this.smScreen = result.matches));
    this.breakpointObserver
      .observe([Breakpoints.Small])
      .subscribe((result) => (this.mdScreen = result.matches));
  }

  ngOnInit(): void {}
}
