/* tslint:disable */
/* eslint-disable */
/**
 * My Title
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0.0
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
import { ReportType } from './report-type';
/**
 * 
 * @export
 * @interface ReportRequest
 */
export interface ReportRequest {
    /**
     * 
     * @type {ReportType}
     * @memberof ReportRequest
     */
    reportType: ReportType;
    /**
     * 
     * @type {Date}
     * @memberof ReportRequest
     */
    asof: Date;
    /**
     * 
     * @type {number}
     * @memberof ReportRequest
     */
    groupId: number;
}