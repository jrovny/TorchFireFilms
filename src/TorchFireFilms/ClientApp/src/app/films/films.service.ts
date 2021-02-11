import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { FilmBrowse } from './film-browse';

@Injectable({
  providedIn: 'root',
})
export class FilmsService {
  constructor(private httpClient: HttpClient) {}

  getFilms() {
    return this.httpClient.get<FilmBrowse[]>(
      `${environment.baseUrl}/api/films`
    );
  }

  getFilmById() {
    return this.httpClient.get<FilmBrowse>(
      `${environment.baseUrl}/api/films/1`
    );
  }
}
