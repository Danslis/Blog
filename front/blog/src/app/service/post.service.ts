import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import { Post } from '../interfaces/postResponse';
import { environment } from 'src/environments/environment';


@Injectable({providedIn: 'root'})
export class PostsService {
  constructor(private http: HttpClient) {
  }

  getPosts(): Observable<Post[]> {
    return this.http.get<Post[]>(`${environment.url}/post/get-posts`)
  }

  getPostById(id: number) {
    return this.http.get(`${environment.url}/post/get-posts-by-id/${id}`);
  }

  createPost(post: Post) {
    return this.http.post(`${environment.url}/post/create/`, post);
}
  updatePost(post: Post) {
      return this.http.put(`${environment.url}/post/update/`, post);
  }
  deletePost(id: number) {
      return this.http.delete(`${environment.url}/post/delete/${id}`);
  }
}
