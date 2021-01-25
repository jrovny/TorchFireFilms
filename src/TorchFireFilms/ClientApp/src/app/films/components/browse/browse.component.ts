import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FilmBrowse } from '../../film-browse';
import { FilmsService } from '../../films.service';

@Component({
  selector: 'app-browse',
  templateUrl: './browse.component.html',
  styleUrls: ['./browse.component.scss'],
})
export class BrowseComponent implements OnInit {
  films$: Observable<FilmBrowse[]>;

  constructor(private filmsService: FilmsService) {}

  ngOnInit(): void {
    this.films$ = this.filmsService.getFilms();
  }
}
