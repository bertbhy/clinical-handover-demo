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
import { HandoverLog } from './handover-log';
/**
 * 
 * @export
 * @interface Handover
 */
export interface Handover {
    /**
     * 
     * @type {string}
     * @memberof Handover
     */
    id: string;
    /**
     * 
     * @type {string}
     * @memberof Handover
     */
    patientKey?: string;
    /**
     * 
     * @type {string}
     * @memberof Handover
     */
    patientName?: string;
    /**
     * 
     * @type {Date}
     * @memberof Handover
     */
    dob: Date;
    /**
     * 
     * @type {string}
     * @memberof Handover
     */
    sex?: string;
    /**
     * 
     * @type {string}
     * @memberof Handover
     */
    wardCode?: string;
    /**
     * 
     * @type {string}
     * @memberof Handover
     */
    specialtyCode?: string;
    /**
     * 
     * @type {string}
     * @memberof Handover
     */
    bedNumber?: string;
    /**
     * 
     * @type {Date}
     * @memberof Handover
     */
    admissionTime?: Date;
    /**
     * 
     * @type {string}
     * @memberof Handover
     */
    caseNumber?: string;
    /**
     * 
     * @type {string}
     * @memberof Handover
     */
    freeText?: string;
    /**
     * 
     * @type {string}
     * @memberof Handover
     */
    diagnosis?: string;
    /**
     * 
     * @type {string}
     * @memberof Handover
     */
    background?: string;
    /**
     * 
     * @type {string}
     * @memberof Handover
     */
    progress?: string;
    /**
     * 
     * @type {string}
     * @memberof Handover
     */
    ix?: string;
    /**
     * 
     * @type {string}
     * @memberof Handover
     */
    drugs?: string;
    /**
     * 
     * @type {string}
     * @memberof Handover
     */
    recommendation?: string;
    /**
     * 
     * @type {string}
     * @memberof Handover
     */
    editedBy?: string;
    /**
     * 
     * @type {number}
     * @memberof Handover
     */
    groupId?: number;
    /**
     * 
     * @type {Array<HandoverLog>}
     * @memberof Handover
     */
    log?: Array<HandoverLog>;
}