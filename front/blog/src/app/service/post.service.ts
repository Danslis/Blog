import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import { Post } from '../interfaces/postResponse';

@Injectable({providedIn: 'root'})
export class PostsService {
  baseUrl: string;
  constructor(private http: HttpClient) {
    this.baseUrl = "http://localhost:5000";
  }

  getPosts(): Observable<Post[]> {
    return this.http.get<Post[]>(`${this.baseUrl}/post/get-posts`)
  }

  getPostById(id: number) {
    return this.http.get(`${this.baseUrl}/post/get-posts-by-id/${id}`);
  }

  createPost(post: Post) {
    return this.http.post(`${this.baseUrl}/post/create/`, post);
}
  updatePost(post: Post) {
      return this.http.put(`${this.baseUrl}/post/update/`, post);
  }
  deletePost(id: number) {
      return this.http.delete(`${this.baseUrl}/post/delete/` + '/' + id);
  }
}
