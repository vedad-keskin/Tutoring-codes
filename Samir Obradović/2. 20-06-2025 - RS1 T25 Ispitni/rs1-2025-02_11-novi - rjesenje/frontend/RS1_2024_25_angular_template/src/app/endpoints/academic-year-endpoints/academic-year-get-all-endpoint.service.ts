import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface AcadmicYearGetAllResponse {
  id: number;
  name: string;
}

@Injectable({
  providedIn: 'root'
})
export class AcadmicYearGetAllEndpoint implements MyBaseEndpointAsync<void, AcadmicYearGetAllResponse[]> {
  private apiUrl = `${MyConfig.api_address}/academicYears/all`;

  constructor(private httpClient: HttpClient) {
  }

  handleAsync() {
    return this.httpClient.get<AcadmicYearGetAllResponse[]>(`${this.apiUrl}`);
  }
}
