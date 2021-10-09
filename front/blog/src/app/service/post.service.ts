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
    return this.http.get<Post[]>(`${this.baseUrl}/blog/get-posts`)
  }

  getPostById(id: number) {
    return this.http.get(`${this.baseUrl}/blog/get-posts-by-id` + '/' + id);
  }

  createPost(post: Post) {
    return this.http.post(`${this.baseUrl}/blog/create/`, post);
}
  updatePost(post: Post) {
      return this.http.put(`${this.baseUrl}/blog/update/`, post);
  }
  deletePost(id: number) {
      return this.http.delete(`${this.baseUrl}/blog/delete/` + '/' + id);
  }
}
