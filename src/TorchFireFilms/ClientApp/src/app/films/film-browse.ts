export interface FilmBrowse {
  filmId: number;
  title: string;
  description?: string;
  runtimeMinutes: number;
  releaseDate: Date;
  image?: string;
}
