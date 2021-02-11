import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Observable } from 'rxjs';
import { FilmBrowse } from '../../film-browse';
import { FilmsService } from '../../films.service';

@Component({
  selector: 'app-browse',
  templateUrl: './browse.component.html',
  styleUrls: ['./browse.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class BrowseComponent implements OnInit {
  films$: Observable<FilmBrowse[]>;
  film$: Observable<FilmBrowse>;

  constructor(private filmsService: FilmsService) {}

  ngOnInit(): void {
    this.films$ = this.filmsService.getFilms();

    // this.films$.subscribe((film) => console.log(film));
    // this.filmsService.getFilmById().subscribe((film) => console.log(film));
  }

  openFilm() {
    console.log('Opening film');
  }
}
